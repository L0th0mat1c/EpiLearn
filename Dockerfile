FROM ubuntu:latest

COPY . ./

# RUN sh -c 'echo "deb https://hub.unity3d.com/linux/repos/deb stable main" > /etc/apt/sources.list.d/unityhub.list'



RUN apt-get update \
 && apt-get install wget unzip zip -y
 
RUN apt-get install -y apt-transport-https
RUN apt-get -y install gnupg
RUN wget -qO - https://hub.unity3d.com/linux/keys/public | apt-key add -
# RUN apt update
RUN apt install -y libgtk-3-0
RUN apt install -y libcurl4
RUN apt install -y libarchive13

RUN apt-get -y install unityhub
RUN unityhub install --version 2021.3.11f1 --changeset 0a5ca18544bf --module android

RUN chmod +x UnitySetup-2021.3.11f1
RUN yes | ./UnitySetup-2021.3.11f1 --unattended --install-location=/Unity

# RUN apt install libgl1-mesa-glx
# RUN ./Unity/Editor/Unity -buildTarget android
