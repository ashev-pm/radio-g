const http = require('http').Server();
const httpGet = require('http').get;
const io = require('socket.io')(http);
const state = {
  title: "",
  artist: ""
}
const trackNameEvent = 'trackName';

setInterval(() => {
  httpGet('http://35.224.48.39:8000/status-json.xsl', (res) => prcessRequest(res)).on('error', (e) => {
    console.error(`Got error: ${e.message}`);
  });
}, 1000);

http.listen(3000, () => {
  console.log('listening on *:3000');
});

io.on('connection', function(socket){
  socket.emit(trackNameEvent, state); 
});

function prcessRequest(res) {
  validateResponse(res).match(
    _ => getJsonResult(res),
    error => {
      console.error(error.message);
      res.resume();
    });
}

function validateResponse(res) {
  const {
    statusCode
  } = res;

  const contentType = res.headers['content-type'];
  const result = new Result();

  if (statusCode !== 200) {
    result.error = new Error('Request Failed.\n' +
      `Status Code: ${statusCode}`);
  } else if (!/^application\/json/.test(contentType)) {
    result.error = new Error('Invalid content-type.\n' +
      `Expected application/json but received ${contentType}`);
  }
  return {
    match: matching.bind(result)
  };
}

function getJsonResult(res) {
  res.setEncoding('utf8');
  let rawData = '';
  res.on('data', (chunk) => {
    rawData += chunk;
  });
  res.on('end', () => {
    try {
      const stats = JSON.parse(rawData);
      const data = stats.icestats.source.filter(x=>x.server_name === 'black.mp3')[0];
      if (state.title === data.title 
          && state.artist === data.artist) 
        return;
      state.title = data.title;
      state.artist = data.artist;
      io.emit(trackNameEvent, state);
    } catch (e) {
      console.log(e.message);
    }
  });
}

function Result() {
  this.error = null;
  this.data = null;
}

function matching(functionSuccess, functionWrong) {
  if (this.error) {
    functionWrong(this.error);
  } else {
    functionSuccess(this.data);
  }
}
