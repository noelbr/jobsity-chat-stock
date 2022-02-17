# jobsity-chat-stock

Jobsity challenge

## Description 

Using docker to set the environment setup, SignalR to real-time communication chat,  rabbitQM to handlle the queue messages and swaggler to document the api endpoints

* jobsity_chat : web application chat write in C# with MVC
* jobsite_stockWorker : console application to watch the RabbitQM queues and get the stock quote then send do the chat 

### Dependencies

* Docker

## How to executing the project 


build the environment 

```
docker-compose build
```

executing the project
```
docker-compose up
```

go to http://localhost:5000 to open the chat 


other important endpoints 

http://localhost:5000/swagger : this the api to reciver the notification from jobsite_worker 


## Authors

* Natanael Silva [natanaelfs@gmail.com]
