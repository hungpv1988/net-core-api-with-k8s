# docker-net-mvc-sample

1. Start k8s: minikube start --vm-driver=hyperv --hyperv-virtual-switch="Primary Virtual Switch" --memory 4096 --alsologtostderr -v=9
2. If you only want to run webapp or webapi at you local machine, ignore 3 and go to 4
3. run @FOR /f "tokens=*" %i IN ('minikube docker-env') DO @%i  to talk directly with master node
4. Build images. A note here is that images are built, and stored in k8s cluster, not your local repo if you run the statement in step 2.
Run two statements below
docker build -t aspnetcoreapp.
docker build -t aspnetwebapi.

If  (2) is ignored, then, run statement belows to launch web app
docker run -d -p 8080:80 --name aspnetcoreapp aspnetcoreapp

Note: some article says that we should use docker's IP like the following

Go to localhost:8080 to access your app in a web browser.
If you are using the Nano Windows Container and have not updated to the Windows Creator Update there is a bug affecting how Windows 10 talks to Containers via “NAT” (Network Address Translation). You must hit the IP of the container directly. You can get the IP address of your container with the following steps:
Run docker inspect -f "{{ .NetworkSettings.Networks.nat.IPAddress }}" myapp
Copy the container IP address and paste into your browser. (For example, 172.16.240.197)

but in this case, I can still access via localhost:8080
maybe, the new version docker and netcore make it work

You need to configure web api end point and use accordingly in webapp. To run web api, do the same as web app above

5. From this step, assume that you run (2). run the statement 
kubectl create -f helloworld.yaml

6. to access web app

After deploying everything, to be able to access service/site, there are some options
First, let’s get pod’s ip by using “kubectl describe pods”, and then, use pod’s id to access the site (e.g. Node:  minikube/10.120.105.29) like 10.120.105.29:port_defined_in_yaml. Or use this statement 
Second, minikube service mysuperaspcore --url (mysuperaspcore  is app name), and then, url is displayed. You should use this url to access the site
Third, minikube service mysuperaspcore (mysuperaspcore  is app name), site/service is automatically opened for you.

A note that in helloworld.yaml, we do not need to expose web api service to the world. We only need to communicate internally with it via 80 port. It should be enough.



7. In reality, if we have scale up, we can have many nodes and each of them contain web api service. Base on the service name in url calling, k8s will automatically use load balancing and forward request to the suitable node. The port is the same among them.
