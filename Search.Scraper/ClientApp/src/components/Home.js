import React, { useState } from 'react';
import './Home.css';

export function Home() {
    const [urlPositions, setUrlPositions] = useState("");
    const submit = async (event) => {
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
            headers: {'Content-Type': 'application/json'},
        };

        const response = await fetch('url-position-lookup', requestOptions);
        const data = await response.json();

        setUrlPositions(data);
    }

    return (
        <div className="container">
            <div className="form-container">
                <form onSubmit={(event) => submit(event)}>
                    <p>Enter a keyword:</p>
                    <input className="input-field" type={"search"} placeholder={"Enter keyword(s)"} name={"keywords"} required/>
                    <p>Enter a URL:</p>
                    <input className="input-field" type={"search"} placeholder={"Enter url"} name={"url"} required/>
                    <button className="submit-button" type={"submit"}>Submit</button>
                </form>
            </div>

            <div className="results-container">
                <p>The positions the URL appears in Google search results for the given keyword:</p>
                {urlPositions}
            </div>
        </div>
    );
}
