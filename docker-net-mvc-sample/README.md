# docker-net-mvc-sample

Remember to rename "Hello" folder by "aspnetcoreapp"
Run two statements below
docker build -t mynetmvcapp .
docker run -d -p 8080:80 --name firstmvcapp mynetmvcapp

Note: some article says that we should use docker's IP like the following

Go to localhost:8080 to access your app in a web browser.
If you are using the Nano Windows Container and have not updated to the Windows Creator Update there is a bug affecting how Windows 10 talks to Containers via “NAT” (Network Address Translation). You must hit the IP of the container directly. You can get the IP address of your container with the following steps:
Run docker inspect -f "{{ .NetworkSettings.Networks.nat.IPAddress }}" myapp
Copy the container IP address and paste into your browser. (For example, 172.16.240.197)

but in this case, I can still access via localhost:8080
maybe, the new version docker and netcore make it work
