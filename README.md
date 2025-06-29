# 🌤️ Using the REST API in .NET MAUI

Using the REST API in .NET MAUI applications enables interaction with web services to retrieve, send, update or delete data via HTTP requests. 

It is necessary to use `HttpClient` to send different types of HTTP requests (`GET`, `POST`, `PUT`, `DELETE`) to the REST API.  
It is a class used to send HTTP requests and receive HTTP responses from the REST API.  
The logic of using requests is similar to the other tools we've used so far, but the difference is in the implementation in the code.

---

## 🔁 HTTP Request Types

### ✅ GET REQUEST
Uses the `GetAsync` method to send a request to a specified URL and retrieves a list of objects.  
If the request is successful (`IsSuccessStatusCode`), the corresponding JSON structure is unpacked into a list of objects that we define in the code.

### ✏️ PUT REQUEST
Updates an existing user record based on an ID.  
The serialized JSON with the new data is sent to the URL using the `PutAsync` method.

### ➕ POST REQUEST
This request creates a new user by sending JSON data to a specified URL.  
The JSON is serialized from the `User` object and sent as `StringContent`.

### ❌ DELETE REQUEST
Deletes an object with a specified parameter using the `DeleteAsync` method.

---

## 📍 Geolocation in .NET MAUI

The use of geographic location in .NET MAUI applications allows access to the geographic coordinates (latitude and longitude)  
of the user or for a specific address, which can be useful for functionalities such as location tracking,  
displaying the user's position on a map, or obtaining information about the exact location based on the entered data.  

That is, in my case, for the locations of the cities where I want to see the weather forecast for that day and the next week.  

In the project, I used the Geocoding API, which is built into .NET MAUI, to convert the address into geographic coordinates.  
Geocoding is a process that enables retrieving coordinates based on an entered address.

---

## 🌦️ Free Weather API

In order to get free information about the weather forecast, I used **Free Weather Api**.  
(Source: *Open-meteo, n.d.*)

---

## 📸 App Screenshot

![image](https://github.com/user-attachments/assets/d2da6022-2b00-4100-aee9-9734ff8a649f)
