// Initial flight data
const departureList = [
  {
    time: "15:05",
    flight: "NH 0175",
    destination: "TOKYO",
    gate: "D02",
    status: "Departed",
  },
  {
    time: "15:15",
    flight: "WN 0612",
    destination: "LAS VEGAS",
    gate: "B09",
    status: "Departed",
  },
  {
    time: "13:11",
    flight: "AS 3188",
    destination: "NEW YORK",
    gate: "D12",
    status: "Boarding",
  },
  {
    time: "13:37",
    flight: "BA 1760",
    destination: "SAN FRANCISCO",
    gate: "B20",
    status: "Delayed",
  },
  {
    time: "12:50",
    flight: "F9 0970",
    destination: "LONDON",
    gate: "C11",
    status: "On Time",
  },
];


const initialFlights = departureList.map(
  flight => ({ ...flight })
);


const destinations = [
  "TOKYO",
  "LONDON",
  "NEW YORK",
  "PARIS",
  "DUBAI",
  "SINGAPORE",
  "CHENNAI",
  "DELHI",
  "MUMBAI",
  "SYDNEY",
  "CHICAGO",
  "BOSTON",
  "LAS VEGAS",
  "LOS ANGELES",
  "TORONTO",
];

const airlines = [
  "AI","BA", "UA","DL", "NH", "F9","WN","EK","SQ","QR",
];

const times = [ "12:40","12:59", "13:11","13:37", "14:05","14:20","14:35","14:50", "15:05","15:15", "16:30","17:10","17:45","18:20",
];


const board = document.getElementById("board");
const clock = document.getElementById("clock");

const totalFlights =document.getElementById("totalFlights");

const boardingCount =document.getElementById("boardingCount");

const delayedCount =document.getElementById("delayedCount");

const departedCount =document.getElementById("departedCount");

const addBtn = document.getElementById("addBtn");

const resetBtn =document.getElementById("resetBtn");


function getStatusClass(status) {
  if (status === "On Time") {
    return "status-ontime";
  }
  else if (status === "Boarding") {
    return "status-boarding";
  }
  else if (status === "Delayed") {
    return "status-delayed";
  }
  else {
    return "status-departed";
  }
}


function createDepartureRow(flight) {

  const row =document.createElement("div");

  row.className = "flight-row";

  const time = document.createElement("span");
  time.textContent = flight.time;

  const flightNo =document.createElement("span");
  flightNo.textContent = flight.flight;

  const destination =document.createElement("span");
  destination.textContent =flight.destination;

  const gate = document.createElement("span");
  gate.textContent = flight.gate;

  const status =document.createElement("span");

  status.textContent = flight.status;

  status.className =getStatusClass(flight.status);

  row.appendChild(time);
  row.appendChild(flightNo);
  row.appendChild(destination);
  row.appendChild(gate);
  row.appendChild(status);

  return row;
}


function renderDepartures() {

  board.innerHTML = "";

  departureList.forEach(function (
    flight
  ) {
    const row =createDepartureRow(flight);

    board.appendChild(row);
  });

  updateSummary();
}


function updateSummary() {

  totalFlights.textContent = departureList.length;

  const boarding = departureList.filter(
      function (flight) {
        return (
          flight.status ==="Boarding"
        );
      }
    ).length;

  const delayed = departureList.filter(
      function (flight) {
        return (
          flight.status ==="Delayed"
        );
      }
    ).length;

  const departed =departureList.filter(
      function (flight) {
        return (
          flight.status ==="Departed"
        );
      }
    ).length;

  boardingCount.textContent =boarding;

  delayedCount.textContent =delayed;

  departedCount.textContent =departed;
}


addBtn.addEventListener("click",
  function () {

    const randomDestination =destinations[
        Math.floor(
          Math.random() *
          destinations.length
        )
      ];

    const randomAirline = airlines[
        Math.floor(
          Math.random() *
          airlines.length
        )
      ];

    const randomTime =times[
        Math.floor(
          Math.random() *
          times.length
        )
      ];

    const randomGate =String.fromCharCode(
        65 +
        Math.floor(
          Math.random() * 4)) +
      (
        1 +
        Math.floor(
          Math.random() * 25
        )
      );

    const newFlight = {
 time: randomTime,
      flight:
        randomAirline +
        " " +
        Math.floor(
          1000 +
          Math.random() * 9000
        ),
      destination:
        randomDestination,
      gate: randomGate,
      status: "On Time",
    };

    departureList.push(
      newFlight
    );

    renderDepartures();
  }
);


resetBtn.addEventListener(
  "click",
  function () {

    departureList.length = 0;

    initialFlights.forEach(
      function (flight) {
        departureList.push({
          ...flight,
        });
      }
    );

    renderDepartures();
  }
);


function updateClock() {
  const now = new Date();

  clock.textContent =
    now.toLocaleTimeString();
}

updateClock();
setInterval( updateClock,1000);


setInterval(function () {

  if (
    departureList.length === 0
  ) {
    return;
  }

  const randomIndex = Math.floor(
      Math.random() *
      departureList.length
    );

  const flight = departureList[randomIndex];

  if (
    flight.status ===
    "On Time"
  ) {
    flight.status =
      "Boarding";
  }
  else if (
    flight.status ===
    "Boarding"
  ) {
    flight.status =
      "Departed";
  }

  renderDepartures();

}, 5000);


renderDepartures();