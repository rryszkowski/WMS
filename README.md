# WMS
This is a sample project of Warehouse Management System presenting usage of full CQRS. There are two separate physical databases from different vendors which are handled by different ORMs. Replication is handled by a message broker.

## Architecture
The project is built using Clean Architecture. It is divided into 3 layers:
* Application - use cases
* Domain - domain objects
* Infrastructure - infrastructure layer

## Technologies
* .Net 7.0
* CQRS
* EF Core
* Dapper
* MediatR
* Docker
* REST
* PostgreSQL
* MySQL
* RabbitMQ
* MassTransit
* Minimal API
* DbUp
* SQL

## Databases
* Write - this is a PostgreSQL database responsible for writes. It is handled by Entity Framework. It is built with EF migrations.
* Read - this is a MySQL database responsible for reads. It is handled by Dapper. It is built with SQL scripts and DbUp migrations.

There is a full replication using RabbitMQ with MassTransit. Whenever some modification occurs, a message is sent, and a proper consumer performs an SQL script with dapper.

Despite having full replica on read side, there are two tables optimized for reads with are built with triggers, and three views. Replication is only for the sake of building these tables and views.

## Calls
API is created with minimal API, which in turn sends MediatR message to a handler. In handler there is a database operation performed with EF. When save is successfull, the message is published with MasstTransit to RabbitMQ, which is handled by a consumer. There, a database write is performed to the read database with Dapper.

Whenever a read occurs, there is a query performed with MediatR message, which is passed to a handler, where a call is performed to a read database with Dapper.