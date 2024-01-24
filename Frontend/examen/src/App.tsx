import React, { useEffect } from 'react';
import logo from './logo.svg';
import './App.css';
import axios from 'axios';
import { BoredResponse } from './BoredResponse';
import { Dog } from './Dog';
import { config } from './config';


function App() {

  const [pressCount, setPressCount] = React.useState(0);
 
  const [name, setName] = React.useState("");
  const [rasa, setRasa] = React.useState("");
  const [culoare, setCuloare] = React.useState("");
  const [lastDog, setLastDog] = React.useState<Dog | null>(null);
  const [responseData, setResponseData] = React.useState<any[]>([]);

  

  return (
    <div className="App">
      <header className="App-header">
        <p>
          Test
        </p>
        
        <p>Ai apasat butonul de {pressCount}</p>
        <button onClick = {() => setPressCount(pressCount + 1)}>
          Press me
        </button>

        <form style={{display: 'flex', flexDirection: 'column'}} onSubmit={(e)=>{e.preventDefault()}}>
          <label> Nume </label>
          <input value={name} className='form-input' type = "text" onChange={(e) => {
            setName(e.target.value);
          }}/>
          <label> Rasa </label>
          <input value={rasa} className='form-input' type = "text" onChange={(e) => {
            setRasa(e.target.value);
          }}/>
          <label> Culoare </label>
          <input value = {culoare} className = 'form-input' type = "text" onChange={(e) => {
            setCuloare(e.target.value);
          }}/>
          <button className='button' onClick = {() => {
            axios.post("https://localhost:7032/api/Dog", {
              Nume: name,
              Rasa: rasa,
              Culoare: culoare
            }, config).then((response) => {
              setLastDog(response.data);
            })
            
            setCuloare("");
            setName("");
            setRasa("");
          }}>Adauga animal</button>
        </form>

        <p>Afiseaza toti cainii</p>
        <button onClick = {() => {
            axios.get("https://localhost:7032/api/Dog", config).then((response): void => {
            console.log(response.data);
            setResponseData(response.data);})
        }}>Afiseaza</button>
          
          {
            responseData 
            ? (
              <div>
                {responseData.map((dog) => {
                  return (
                    <div>
                      <p>{dog.nume + ' ' + dog.rasa + ' ' + dog.culoare}</p>
                    </div>
                  )
                })}
              </div>
            )
            : "No dogs added yet"
          }
        {
          lastDog ? 
          <>
            <p>{lastDog.id}</p>
            <p>{lastDog.nume}</p>
            <p>{lastDog.rasa}</p>
            <p>{lastDog.culoare}</p>
          </> : "No dog added yet"
        }
      </header>
    </div>
  );
}

export default App;
