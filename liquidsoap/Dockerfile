FROM debian:10-slim

RUN apt-get -q update && \
    apt-get -q -y install liquidsoap supervisor festival sox && \
    apt-get clean


COPY ./radio-mp3.liq /config/config.liq
RUN chown liquidsoap /config/config.liq && mkdir -p /opt/liquidsoap/playlists/mp3 && chown liquidsoap /opt/liquidsoap/playlists/mp3

USER liquidsoap


CMD ["liquidsoap", "/config/config.liq"]