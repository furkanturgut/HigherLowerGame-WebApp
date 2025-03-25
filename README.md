# HigherLower Game

## 1. About the Project
**HigherLower Game** is an entertaining web game that allows users to make correct guesses by comparing different criteria (such as country or league-based). The game offers various game modes where players make "higher or lower" style choices based on data.

## Technologies Used
* **Backend:** .NET Web API, MySQL, Entity Framework Core, Automapper
* **Frontend:** React, TypeScript, Tailwind CSS

## 2. Installation and Running

### Prerequisites
* Node.js (for Frontend)
* .NET SDK (for Backend)
* MySQL database

### Backend Setup
1. **Clone the repository.**
2. **Database Settings:**
   * Update MySQL connection details in the `appsettings.json` file.
3. **Database Migrations:**
   * Apply necessary migrations using Entity Framework Core.
4. **Start the Server:**

```bash
dotnet run
```

### Frontend Setup
1. **Navigate to the frontend folder.**
2. **Install Dependencies:**

```bash
npm install
```

3. **Start Development Server:**

```bash
npm start
```

## 3. Usage
* **Game Modes:**
   * **Normal Mode:** User directly transitions to the game screen.
   * **Filter Modes:** User is first directed to an additional selection screen based on nationality or league, then the game is initiated.
* **Game Flow:**
   1. Select a mode from the home page.
   2. If a filter mode is selected, make your choice from the relevant selection screen ("Choose Nation" or "Choose League").
   3. After your selection, proceed to the game screen and compare player values.

## 4. API Details
The project provides the following API endpoints for player and related data:

### Player Operations
* **Create:** `POST /api/Player`
* **Retrieve Single:** `GET /api/Player/{id}`
* **Retrieve Multiple:** `GET /api/Player?PageNumber=1&PageSize=10`
   * Supports filtering, pagination, etc.
* **Update:** `PUT /api/Player/{id}`
* **Delete:** `DELETE /api/Player/{id}`

### Additional Endpoints
* **Countries, Teams, Leagues:** Similar endpoints exist for managing country, team, and league data.

## 5. Project Structure
* **Backend:** `HigherLower.API`
* **Frontend:** `HigherLower.Client`
* **Database:** MySQL
* **Models:** Player, Country, Team, League, etc.
* **Services:** CRUD services for Player, Team, League

## 6. AI Usage
**Extensive AI support was used during frontend development**. UI/UX decisions were made using vibe coding methodology. AI suggestions were particularly evaluated during React component and Tailwind CSS implementation.

## 7. License
This project is open-source, and no specific license information has been provided.

## 8. Future Updates
* **Options to play by league or nationality will be added.**
* **More detailed statistics for players will be included.**
