#docker
sudo apt update -y
sudo apt install apt-transport-https ca-certificates curl gnupg2 software-properties-common -y
curl -fsSL https://download.docker.com/linux/debian/gpg | sudo apt-key add -
sudo add-apt-repository \
   "deb [arch=amd64] https://download.docker.com/linux/debian \
   $(lsb_release -cs) \
   stable"
sudo apt update -y
sudo apt install docker-ce docker-ce-cli containerd.io -y
sudo groupadd docker
sudo usermod -aG docker $USER
sudo apt install -y curl wget

curl -s https://api.github.com/repos/docker/compose/releases/latest \
  | grep browser_download_url \
  | grep docker-compose-Linux-x86_64 \
  | cut -d '"' -f 4 \
  | wget -qi -

chmod +x docker-compose-Linux-x86_64
sudo mv docker-compose-Linux-x86_64 /usr/local/bin/docker-compose

#nodejs
sudo apt-get install curl software-properties-common
curl -sL https://deb.nodesource.com/setup_12.x | sudo bash -
sudo apt install nodejs

#vuejs
sudo npm install -g @vue/cli
sudo npm install -g @vue/cli-service

#liquidsoap
sudo apt install liquidsoap -y
sudo cp ~/radio-g/liquidsoap/liquidsoap.service /etc/systemd/system/liquidsoap.service
sudo cp -r ~/radio-g/liquidsoap/ /usr/share/liquidsoap/
sudo systemctl start liquidsoapd.service

#icecast
#sudo apt install icecast2 -y