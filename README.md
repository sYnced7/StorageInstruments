# StorageInstruments

An application to manage band instruments

## Project objective

Just to learn how to build an application with .net core, learn new things and consolidate knowledge

## TODO

- [x] Create a simple app with view & CRUD functions.
- [x] Apply Entity Framework & Repository Layer
- [x] Rest Api
- [x] Swagger
- [ ] Create a client with react
- [x] Improve Architecture(Add a service layer to perform comunications with data layer)
- [ ] Create good unit tests
- [ ] Add a messaging protocol(like kafka or rabittmq).
- [ ] Add User/Login support and analyze possible new features with database changes
- [ ] Secure Rest API with jwt


## Installation

```

// root of project

// Build the system (it will take a while) 
docker-compose build
// Run project
docker-compose up

```

Open browser on:

- [StorageInstruments web page](http://localhost:5001/Instruments) 
- [Swagger Documentation](http://localhost:5001/swagger/index.html) 

## Usage
# OpenAPI/Swagger - UI
![alt text](https://github.com/sYnced7/StorageInstruments/blob/master/documentation/swagger/window.PNG)

# UI(Without usage of API)
- Index
![alt text](https://github.com/sYnced7/StorageInstruments/blob/master/documentation/web-ui/index.PNG)

- Add New
![alt text](https://github.com/sYnced7/StorageInstruments/blob/master/documentation/web-ui/addnew.PNG)

- Edit
![alt text](https://github.com/sYnced7/StorageInstruments/blob/master/documentation/web-ui/editing.PNG)

- Delete
![alt text](https://github.com/sYnced7/StorageInstruments/blob/master/documentation/web-ui/delete.PNG)
