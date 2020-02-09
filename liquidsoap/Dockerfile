FROM debian:10-slim

RUN apt-get -q update && \
    apt-get -q -y install liquidsoap supervisor festival sox && \
    apt-get clean


COPY ./radio-mp3.liq /usr/share/liquidsoap/radio-mp3.liq
COPY ./radio.liq /usr/share/liquidsoap/radio.liq
COPY ./liquidsoaprun /usr/share/liquidsoap/liquidsoaprun

RUN chown liquidsoap /usr/share/liquidsoap/ \
    && mkdir -p /opt/liquidsoap/playlists/mp3 && chown liquidsoap /opt/liquidsoap/playlists/mp3

USER liquidsoap

CMD ["sh", "/usr/share/liquidsoap/liquidsoaprun"]