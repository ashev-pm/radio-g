FROM node:alpine

LABEL maintainer="ao003587@gmail.com"

WORKDIR /app

RUN npm install -g nodemon

COPY package*.json ./

RUN npm install

COPY src /app

EXPOSE 3000
CMD [ "node", "index.js" ]