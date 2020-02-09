#!/usr/bin/liquidsoap
# Log dir
set("log.file.path","/var/log/liquidsoap/remote-radio1.log")

music = mksafe(playlist("/opt/liquidsoap/playlists/mp3"))
#tech = playlist.safe("/opt/liquidsoap/playlists/tech")


#radio = fallback(
# [ switch(
#   [
#  ({ 0h-12h }, music),
#  ({ 12h01-23h59}, tech),
#	]), 
#  tech])

# radio = random(weights=[1,5],[ jingles,radio ])

# Stream it
output.icecast(%mp3, host = "icecast", port = 8000, password = "hackme", mount = "remote-radio.mp3", music)
