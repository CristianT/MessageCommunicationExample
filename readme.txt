1 install docker
You can download it on the following link: https://hub.docker.com/editions/community/docker-ce-desktop-windows/

2 make sure docker runs: 
Also, you need to download the following .zip file which contains two.bat files for enable and disable Hyper-V in order to be able to execute Docker: https://drive.google.com/file/d/1GjCICsTfvLb5HNnL4dag2Vn-DO7kJpNO/view?usp=sharing

3 in the solution folder execute the command: 'docker-compose up' to start rabbitmq

4 run both project console applications:
MessageCommunicationExampleReceiver.exe
MessageCommunicationExample.exe

5 see the processes communicate