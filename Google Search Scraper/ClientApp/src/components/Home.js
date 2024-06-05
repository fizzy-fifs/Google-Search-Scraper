import React, { Component } from 'react';

export class Home extends Component {
  static displayName = Home.name;

    submit = async (event) => {
        event.preventDefault();
    
        const formData = new FormData(event.target);
    
        formData.set("keyword", formData.get("keywords"));
        formData.set("url", formData.get("url"));
    
        const requestOptions = {
            method: 'POST',
            body: JSON.stringify({
                keyword: formData.get("keyword"),
                url: formData.get("url")
            }),
            headers: { 'Content-Type': 'application/json' },
        };
    
        const response = await fetch('SearchScraper', requestOptions);
        const data = await response.json();
    
        console.log(data);
    }

  render() {
    return (
      <div>
        <h1>Hello, world!</h1>
          <form onSubmit={(event) => this.submit(event)}>
              <input type={"search"} placeholder={"Enter keyword(s)"} name={"keywords"} required/>
              <input type={"search"} placeholder={"Enter url"} name={"url"} required/>
          </form>
      </div>
    );
  }
}
