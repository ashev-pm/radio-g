#!/usr/bin/liquidsoap
# Log dir
set("log.file.path","/var/log/liquidsoap/basic-radio.log")

music = playlist("/opt/liquidsoap/playlists/music")
tech = playlist.safe("/opt/liquidsoap/playlists/tech")

radio = fallback(
 [ switch(
   [
  ({ 0h-12h }, music),
  ({ 12h01-23h59}, tech),
	]), 
  tech])

# radio = random(weights=[1,5],[ jingles,radio ])

# Stream it
output.icecast(%vorbis,
   host = "localhost", port = 8000,
   password = "Secure11", mount = "basic-radio.ogg", 
   radio)
