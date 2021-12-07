
# Cats API

This is a REST API linked to a database containing cat breeds, a short description and an image of the breed.

## API Reference
#### Get all cats

this request allows me to obtain the complete list of cat breeds

```
  GET /v1/cats
```
#### Get cat

this request allows me to obtain a specific breed of cat by means of its Id.

```
  GET /v1/cats/{id}
```
#### Create cat

this request allows me to create a new breed of cats

```
  POST /v1/cats
```

#### Edit cat

this request allows me to update a breed of cats

```
  PUT /v1/cats
```
#### Delete cat

this request allows me to remove a breed of cats

```
  DELETE /v1/cats/{id}
```

# gRPC and REST

![Image API](https://www.imaginarycloud.com/blog/content/images/2021/06/API.png)
![Image gRPC](https://www.imaginarycloud.com/blog/content/images/2021/06/Streaming_gRPCvsREST.png)

## gRPC vs REST: comparison table

|Features| REST | gRPC     |
|:-------  | :-------- | :------- |
| **HTTP 1.1 vs HTTP 2**| Follows a request-response model of communication and is typically built on HTTP 1.1 | Follows a client-response model of communication and is built on HTTP 2, which allows for: streaming communication and bidirectional support |
|**Streaming vs. Request/Response**|we can only perform a request and get a response kind of thing. This is due to the HTTP/1.1 protocol it uses for communication which is quite limited in various aspects of things.|we have known uses HTTP/2 for communication. Using TCP connection, HTTP/2 supports multiple data streaming from the server alongside the traditional request-response (Bi-directional streaming, Server streaming and Client streaming)|
|**Payload Data Structure**|REST mainly relies on JSON or XML formats to send and receive data.|gRPC uses Protocol Buffer by default to serialize payload data.|
|**Code Generation Features**|Developers must use a third-party tool like Swagger or Postman to produce code for API requests.|gRPC has native code generation features.|
|**Browser Support**|Universal browser support.|Limited browser support. gRPC requires gRPC-web and a proxy layer to perform conversions between HTTP 1.1 and HTTP 2.|




