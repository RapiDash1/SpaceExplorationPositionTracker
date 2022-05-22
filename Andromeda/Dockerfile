FROM nginx

WORKDIR /app

COPY ./ ./

EXPOSE 8080

CMD ["/bin/bash", "-c", "nginx -c ../../app/conf/nginx.conf -g 'daemon off;'"]