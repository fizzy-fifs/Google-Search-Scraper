import React, { useState } from 'react';

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
            <div>
                <div>
                    <form onSubmit={(event) => submit(event)}>
                        <input type={"search"} placeholder={"Enter keyword(s)"} name={"keywords"} required/>
                        <input type={"search"} placeholder={"Enter url"} name={"url"} required/>
                        <button type={"submit"}>Submit</button>
                    </form>
                </div>
                
                <div>
                    {urlPositions}
                </div>
            </div>
        );
}
