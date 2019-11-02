#!/usr/bin/liquidsoap
# Log dir
set("log.file.path","/var/log/liquidsoap/radio-mp3.log")

music = mksafe(playlist("/opt/liquidsoap/playlists/mp3"))

# Stream it
output.icecast(%mp3, host = "icecast", port = 8000, password = "hackme", mount = "black.mp3", music)
