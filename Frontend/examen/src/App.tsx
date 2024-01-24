import React, { useEffect } from 'react';
import logo from './logo.svg';
import './App.css';
import axios from 'axios';
import { BoredResponse } from './BoredResponse';
import { Dog } from './Dog';
import { config } from './config';
import { Button, ListGroup } from 'react-bootstrap';
import '../node_modules/bootstrap/dist/css/bootstrap.min.css';


function App() {

  const [pressCount, setPressCount] = React.useState(0);
 
  const [name, setName] = React.useState("");
  const [rasa, setRasa] = React.useState("");
  const [culoare, setCuloare] = React.useState("");
  const [owner, setOwner] = React.useState("");
  const [prenume, setPrenume] = React.useState("");
  const [adresa, setAdresa] = React.useState("");
  const [telefon, setTelefon] = React.useState("");
  const [email, setEmail] = React.useState("");
  const [lastDog, setLastDog] = React.useState<Dog | null>(null);
  const [responseData, setResponseData] = React.useState<Dog[]>([]);

  

  return (
    <div className="App">
      <header className="App-header">
        <p>
          Test
        </p>
        
        <p>Ai apasat butonul de {pressCount}</p>
        <Button variant = "primary" onClick = {() => setPressCount(pressCount + 1)}>
          Press me
        </Button>

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
        <Button variant = "primary" onClick = {() => {
            axios.get("https://localhost:7032/api/Dog", config).then((response): void => {
            console.log(response.data);
            setResponseData(response.data);})
        }}>Afiseaza</Button>
          
          {
            responseData 
            ? (
              <div>
                <ListGroup className='mt-3 mb-3'>
                {responseData.map((dog) => {
                  return (
                    <ListGroup.Item>{dog.nume + ' ' + dog.culoare + ' ' + dog.rasa}</ListGroup.Item>
                  )
                })}
                </ListGroup>
              </div>
            )
            : "No dogs added yet"
          }

        
          <form style={{display: 'flex', flexDirection: 'column'}} onSubmit={(e)=>{e.preventDefault()}}>
          <label> Nume </label>
          <input value={owner} className='form-input' type = "text" onChange={(e) => {
            setOwner(e.target.value);
          }}/>
          <label> Prenume </label>
          <input value={prenume} className='form-input' type = "text" onChange={(e) => {
            setPrenume(e.target.value);
          }}/>
          <label> Adresa </label>
          <input value = {adresa} className = 'form-input' type = "text" onChange={(e) => {
            setAdresa(e.target.value);
          }}/>
          <label> Telefon </label>
          <input value = {telefon} className = 'form-input' type = "text" onChange={(e) => {
            setTelefon(e.target.value);
          }}/>
          <label> Email </label>
          <input value = {email} className = 'form-input' type = "text" onChange={(e) => {
            setEmail(e.target.value);
          }}/>
          <button className='button' onClick = {() => {
            axios.post("https://localhost:7032/api/Owner", {
              Nume: owner,
              Prenume: prenume,
              Adresa: adresa,
              Email: email,
              Telefon: telefon
            }, config).then((response) => {
              console.log(response.data);
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
