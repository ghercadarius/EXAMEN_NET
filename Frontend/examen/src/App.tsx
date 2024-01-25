import React, { useEffect } from "react"
import logo from "./logo.svg"
import "./App.css"
import axios from "axios"
import { BoredResponse } from "./BoredResponse"
import { Eveniment } from "./Eveniment"
import { Participant } from "./Participant"
import { config } from "./config"
import { Button, ListGroup } from "react-bootstrap"
import "../node_modules/bootstrap/dist/css/bootstrap.min.css"

function App() {
  const [numeP, setNumeP] = React.useState("")
  const [prenume, setPrenume] = React.useState("")
  const [numeE, setNumeE] = React.useState("")
  const [locatie, setLocatie] = React.useState("")
  const [data, setData] = React.useState("")
  const [responseDataEveniment, setResponseDataEveniment] = React.useState<
    Eveniment[]
  >([])
  const [responseDataParticipant, setResponseDataParticipant] = React.useState<
    Participant[]
  >([])

  return (
    <div className="App">
      <header className="App-header">
        <p>Test</p>

        <form
          style={{ display: "flex", flexDirection: "column" }}
          onSubmit={(e) => {
            e.preventDefault()
          }}
        >
          <label> Nume </label>
          <input
            value={numeP}
            className="form-input"
            type="text"
            onChange={(e) => {
              setNumeP(e.target.value)
            }}
          />
          <label> Prenume </label>
          <input
            value={prenume}
            className="form-input"
            type="text"
            onChange={(e) => {
              setPrenume(e.target.value)
            }}
          />
          <button
            className="button"
            onClick={() => {
              axios.post(
                "https://localhost:7032/api/Participant",
                {
                  Nume: numeP,
                  Prenume: prenume,
                },
                config,
              )
            }}
          >
            Adauga Participant
          </button>
        </form>

        <p>Afiseaza toti Participantii</p>
        <Button
          variant="primary"
          onClick={() => {
            axios
              .get("https://localhost:7032/api/Participant", config)
              .then((response): void => {
                console.log(response.data)
                setResponseDataParticipant(response.data)
              })
          }}
        >
          Afiseaza
        </Button>

        {responseDataParticipant ? (
          <div>
            <ListGroup className="mt-3 mb-3">
              {responseDataParticipant.map((_participant) => {
                return (
                  <ListGroup.Item>
                    {_participant.nume + " " + _participant.prenume}
                  </ListGroup.Item>
                )
              })}
            </ListGroup>
          </div>
        ) : (
          "Nu au fost adaugati participanti inca"
        )}

        <form
          style={{ display: "flex", flexDirection: "column" }}
          onSubmit={(e) => {
            e.preventDefault()
          }}
        >
          <label> Nume </label>
          <input
            value={numeE}
            className="form-input"
            type="text"
            onChange={(e) => {
              setNumeE(e.target.value)
            }}
          />
          <label> Locatie </label>
          <input
            value={locatie}
            className="form-input"
            type="text"
            onChange={(e) => {
              setLocatie(e.target.value)
            }}
          />
          <label> Data </label>
          <input
            value={data}
            className="form-input"
            type="text"
            onChange={(e) => {
              setData(e.target.value)
            }}
          />
          <button
            className="button"
            onClick={() => {
              axios
                .post(
                  "https://localhost:7032/api/Eveniment",
                  {
                    Nume: numeE,
                    Locatie: locatie,
                    Data: data,
                  },
                  config,
                )
                .then((response) => {
                  console.log(response.data)
                })
            }}
          >
            Adauga eveniment
          </button>

          <p>Afiseaza toate Evenimentele</p>
          <Button
            variant="primary"
            onClick={() => {
              axios
                .get("https://localhost:7032/api/Eveniment", config)
                .then((response): void => {
                  console.log(response.data)
                  setResponseDataEveniment(response.data)
                })
            }}
          >
            Afiseaza
          </Button>

          {responseDataEveniment ? (
            <div>
              <ListGroup className="mt-3 mb-3">
                {responseDataEveniment.map((_eveniment) => {
                  return (
                    <ListGroup.Item>
                      {_eveniment.nume +
                        " " +
                        _eveniment.locatie +
                        " " +
                        _eveniment.data}
                    </ListGroup.Item>
                  )
                })}
              </ListGroup>
            </div>
          ) : (
            "Nu au fost adaugate evenimente inca"
          )}
        </form>
      </header>
    </div>
  )
}

export default App
