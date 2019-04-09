const express = require('express');
const bodyParser = require('body-parser');
const app = express();

app.use(bodyParser.json());

app.get('/', function (request, response) {
    response.send('Kolmakov//localhost/-/');
});

app.post('/', function(request, response){
   
});

app.listen(3005);
