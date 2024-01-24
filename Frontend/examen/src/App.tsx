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
            axios.post("http://localhost:5244/api/Dog", {
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
