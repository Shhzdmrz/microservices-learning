# microservices-learning
 learnig microservice architecture 


 ### Check if docker running
 ```docker ps```
 ### Run image container
 ```docker run -d -p 27017:27017 --name shopping-mongo mongo[image name]```
 ### Run/Start existing container
 ``` docker start shopping-mongo[container name]```
 ## Troubleshooting
 ### for loggin
 ```docker logs -f shopping-mongo[container name]```
 ## MongoDB
 ### Open Interactive terminal for mongo db container
 ```docker exec -it shopping-mongo mongosh```
 #### list the databases
 ```show dbs```
 ### create database 
 ```use CatalogDB```
 ### create collections with name
 ```db.createCollection('Products')```
 ### insert item to collection
 ```db.Products.insert()```
 ```db.Products.insertMany()```
 #### Sample insert 
 ```db.Products.insertMany([{ 'Name':'Asus Laptop','Category':'Computers', 'Summary':'Summary', 'Description':'Description', 'ImageFile':'ImageFile', 'Price':54.93 }, { 'Name':'HP Laptop','Category':'Computers', 'Summary':'Summary', 'Description':'Description', 'ImageFile':'ImageFile', 'Price':88.93 } ])```
 ### Show collections 
 ```show collections```
 ### Find all products 
 ```db.Products.find()```
 ```db.Products.find().pretty()```
 ### Remove all products 
 ```db.Products.deleteOne(with brackets)```
 ```db.Products.deleteMany(with brackets)```
 ```db.Products.findOneAndDelete(with brackets)```
 ```db.Products.bulkWrite(with brackets)```

 