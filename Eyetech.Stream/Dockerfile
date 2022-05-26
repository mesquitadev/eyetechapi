FROM node

WORKDIR /app

RUN apt update && apt-get upgrade -y


COPY . ./arquivos
RUN mkdir /app/uploads && mkdir /app/uploads/camera && mkdir /app/alpr && mkdir /app/alpr/Classes/
RUN mkdir /app/uploads/placas/ && mkdir /app/uploads/imagensprocessadas/
RUN cp -R /app/arquivos/* /app/ && cd /app/ && ls
RUN rm -rf arquivos
RUN rm -rf /app/node_modules
RUN chmod -R 777 /app/uploads/
RUN cd /app/ && ls && npm i
# RUN echo "######################################\n\n\n"
# RUN export PYTHONALPR=/app/alpr/main.py
# RUN export PATHALPR=/app/alpr/

# ENV PYTHONALPR=/app/alpr/main.py
# ENV PATHALPR=/app/alpr/

# RUN printenv

RUN apt-get update && apt -y upgrade
# RUN apt-get install -y python3
# RUN apt install -y python3-pip
# RUN python3 -m pip install opencv-python
# RUN apt install -y libsm6 libxext6
# RUN apt install -y openalpr openalpr-daemon openalpr-utils libopenalpr-dev
# RUN apt-get install -y python3-openalpr
# RUN python3 -m pip install requests


RUN ls
RUN npm install -g nodemon
RUN apt-get install ffmpeg -y

EXPOSE 9999

ENTRYPOINT ["nodemon", "--experimental-worker"]