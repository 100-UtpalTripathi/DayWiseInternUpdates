FROM ubuntu

# Install the necessary packages
RUN apt-get update
RUN apt-get install -y curl
RUN apt-get update -y

RUN curl -sL https://deb.nodesource.com/setup_20.x | bash -
RUN apt-get install -y nodejs

# Copy the application files
COPY package.json package.json
COPY package-lock.json package-lock.json
COPY main.js main.js

# Install the application dependencies

RUN npm install
ENTRYPOINT [ "node", "main.js" ]