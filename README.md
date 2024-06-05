<h1> Search Scraper </h1> <br/>

A simple single page application built with React on the client side and .NetCore 6.0 on the serverside. Search Scraper takes in a search phrase/keyword and a url, and returns a string of numbers - positions where the url can found on the google search results page. Search scraper performs a Google search on the keyword, scrapes the results page, extractes the first 100 urls and returns the positions where the user's url appeared in the search results or 0 if the url does not appear in the first 100 links.


<h2>To Run Locally</h2>
Clone this repo <br/>

```
git clone https://github.com/fizzy-fifs/Search-Scraper.git
```
Navigate to the ```ClientApp``` directory

```
cd Search-Scraper/Search.Scraper/ClientApp
```

Install the frontend dependencies

```
npm install
```

Run the .Net App

```
dotnet run
```

Go to ```https://localhost:7293``` or ```http://localhost:5042``` on your browser. This will launch the SPA proxy and launch the React app.
