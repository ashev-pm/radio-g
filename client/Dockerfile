FROM node:alpine

LABEL maintainer="ao003587@gmail.com"

WORKDIR /app

RUN npm install -g http-server

COPY package*.json ./
COPY public ./public

RUN npm install

COPY src /app/src

ARG VUE_APP_STREAM_PROXY_URL
ENV VUE_APP_STREAM_PROXY_URL $VUE_APP_STREAM_PROXY_URL
ARG VUE_APP_STREAM_URL
ENV VUE_APP_STREAM_URL $VUE_APP_STREAM_URL

RUN npm run build

WORKDIR /app/dist

EXPOSE 8080
CMD ["http-server", "-r", "-p", "8080"]