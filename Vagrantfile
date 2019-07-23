Vagrant.configure("2") do |config|
    config.vm.box = "generic/debian9"
   # config.vm.provision "shell", path: "install.vue.sh", privileged: false
   
    config.vm.define "dev-machine" do |dm|
        dm.vm.provider "virtualbox" do |vb|
            vb.customize ["modifyvm", :id, "--cpus", "2"]
            vb.name = "dev-machine-radio-g"
            vb.memory = 2048
        end
        dm.vm.hostname = "dev-machine"
        dm.vm.network "private_network", ip: "172.20.20.31"
    end
    config.vm.synced_folder "./", "/home/vagrant/radiovelikolepie"

end
