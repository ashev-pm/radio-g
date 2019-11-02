FROM alpine:latest

RUN addgroup -S icecast && \
    adduser -S icecast

COPY icecast.xml /etc/icecast.xml
RUN chmod 644 /etc/icecast.xml

RUN apk add --update \
        icecast \
        mailcap && \
    rm -rf /var/cache/apk/*

EXPOSE 8000
VOLUME ["/var/log/icecast"]

CMD icecast -c /etc/icecast.xml