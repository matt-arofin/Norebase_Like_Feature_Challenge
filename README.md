# Like Button Feature Project

## Overview
This project implements a "Like" button feature for articles, allowing users to show their support/appreciation for content and see who and how many others have liked it.

## Features
- Users can like articles, and the count of likes is updated in real-time.
- Articles display the total number of likes.
- New users and articles can be added through included endpoints.

## Getting Started

### Prerequisites
- .NET SDK (version)
- SQL Server or other supported database
- Swagger for API documentation

### Installation
1. Clone the repository
2. Restore dependencies
3. Run migrations (`dotnet ef database update`)
4. Start application (`dotnet run`)
5. View and access endpoints via `http://localhost:7279/swagger` (Can be configured in launchsettings.json)

### Challenge Responses

#### How would the client-side, and server-side + database be structured?
I would implement the client-side using react to render components dynamically (eg article content, like button, like counter, etc). As for the server-side, I've included a limited demonstration of a functional database structure 3 tables (capturing Likes, Users and Articles respectively) and their relationships, while the API endpoints were implemented using the CQRS pattern to separate read and write responsibilities while keeping database operations/access methods cleanly separated and reusable.

### Bonus challenge
#### How can you improve the feature to make it more resilient against abuse/exploitation?
Given more time to develop the concept, I'd implement user authentication to ensure likes are only from real user accounts, as well as rate limiting endpoints to prevent spamming/ddos attacks

#### How can you improve the feature to make it scale to millions of users and perform without issues?
To make this feature scalable, I'd implement load balancing to distribute high request volumes across server instances, as well as caching and database indexing to improve query speed.

#### How will you scale to a million concurrent users clicking the button at the same time
I'd use a message queue to process incoming queues asynchronously and prevent data loss at high volumes. 

#### How will you scale to a million concurrent users requesting the article's like count at the same time
I'd precompute like counts regularly; eg using a background task or worker service to update the cache periodically rather than making fresh db queries in real-time.
