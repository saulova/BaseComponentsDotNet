FROM debian:bookworm

ENV DOTNET_CLI_TELEMETRY_OPTOUT=1

RUN apt-get update 

RUN apt-get install -y --no-install-recommends sudo curl ca-certificates
RUN apt-get install -y git

SHELL ["/bin/bash", "-l", "-c"]

ARG USERNAME=vscode
ARG USER_UID=1000
ARG USER_GID=$USER_UID

RUN groupadd --gid $USER_GID $USERNAME \
  && useradd --uid $USER_UID --gid $USER_GID -m $USERNAME \
  && echo $USERNAME ALL=\(root\) NOPASSWD:ALL > /etc/sudoers.d/$USERNAME \
  && chmod 0440 /etc/sudoers.d/$USERNAME \
  && mkdir -p /home/$USERNAME \
  && chown $USER_UID:$USER_GID /home/$USERNAME

USER $USERNAME

RUN echo "PS1='\e[0;32m\u@\h\e[m:\e[0;34m\w\e[m\$ '" >> /home/$USERNAME/.bashrc

# .NET SDK
RUN curl -o /home/$USERNAME/packages-microsoft-prod.deb https://packages.microsoft.com/config/debian/12/packages-microsoft-prod.deb
RUN sudo dpkg -i /home/$USERNAME/packages-microsoft-prod.deb
RUN rm /home/$USERNAME/packages-microsoft-prod.deb

RUN sudo apt-get update
RUN sudo apt-get install -y dotnet-sdk-9.0

CMD [ "tail", "-f", "/dev/null" ]
