import { check, sleep } from 'k6';
import http from 'k6/http';
import { uuidv4, randomIntBetween } from 'https://jslib.k6.io/k6-utils/1.4.0/index.js';


const params = {
    headers: {
        'Content-Type': 'application/json',
        'X-Tenant': uuidv4(),
        'Authorization': 'Bearer eyJhbGciOiJSUzI1NiIsImtpZCI6Ilg1ZVhrNHh5b2pORnVtMWtsMll0djhkbE5QNC1jNTdkTzZRR1RWQndhTmsiLCJ0eXAiOiJKV1QifQ.eyJhdWQiOiJhNzRjYjE5Mi01OThjLTQ3NTctOTVhZS1iMzE1NzkzYmJiY2EiLCJpc3MiOiJodHRwczovL2NvZGVkZXNpZ25wbHVzLmIyY2xvZ2luLmNvbS8zNDYxZTMxMS1hNjZlLTQ2YWItYWZkZi0yYmJmYjcyYTVjYjAvdjIuMC8iLCJleHAiOjE3Mzc5ODY0NTksIm5iZiI6MTczNzk4Mjg1OSwib2lkIjoiYzAzZjI4ZGEtMTI4Yy00Yzk3LThjZTgtMDAzNmFkY2U1YmU1Iiwic3ViIjoiYzAzZjI4ZGEtMTI4Yy00Yzk3LThjZTgtMDAzNmFkY2U1YmU1IiwiZmFtaWx5X25hbWUiOiJMaXNjYW5vIiwiY2l0eSI6IkJvZ290w6EiLCJwb3N0YWxDb2RlIjoiMTExNjExIiwic3RyZWV0QWRkcmVzcyI6IkNhbGxlIDNhICMgNTNjLTEzIiwic3RhdGUiOiJCb2dvdGEiLCJnaXZlbl9uYW1lIjoiV2lsem9uIiwibmFtZSI6IldpbHpvbiBMaXNjYW5vIiwiY291bnRyeSI6IkNvbG9tYmlhIiwiam9iVGl0bGUiOiJBcmNoaXRlY2giLCJlbWFpbHMiOlsiY29kZWRlc2lnbnBsdXNAb3V0bG9vay5jb20iXSwidGZwIjoiQjJDXzFfQ29kZURlc2VpZ25QbHVzIiwic2NwIjoicmVhZCIsImF6cCI6ImE3NGNiMTkyLTU5OGMtNDc1Ny05NWFlLWIzMTU3OTNiYmJjYSIsInZlciI6IjEuMCIsImlhdCI6MTczNzk4Mjg1OX0.HFoRz6bgSKni99JI0Y4ul29Eho692nrklruTYAVmdQ3Zzn-BLdUewkTxl7lz3NxKsRACdnHkP2LidmllI6sVXkZdcQxxpNh7pPncXSbtHdKnwQLADuJp5GiaeoBaUghL35_nOWJO-GhRiw7N2A_BNkKTVrSQjbztv1K7c8co3AXAjmXjurrFgV0u5gXTMUFG84Hl4G8koyK2bt73Z3dKjOXYI8iGH7ZHwlyjaGPAplVW6wu5VOvWV9YlkOgnVvPaCovkkvogNBXh2NdZtwo_6A7Ets_ya6XuI6Vl3Ztz6GG5XL9g_XDZe-Y-UypcAeTMQP9wwANuPsWkHnxqKcAMDQ'
    },
};

export const options = {
    discardResponseBodies: true,
    scenarios: {
        contacts: {
            executor: 'constant-arrival-rate',
            duration: '120s',

            // How many iterations per timeUnit
            rate: 10,

            // Start `rate` iterations per second
            timeUnit: '1s',

            // Pre-allocate 2 VUs before starting the test
            preAllocatedVUs: 3,

            // Spin up a maximum of 50 VUs to sustain the defined
            // constant arrival rate.
            maxVUs: 5000,
        },
    },
};

export default async function () {

    const random = randomIntBetween(1, 1000);

    const order = JSON.stringify({
        "id": uuidv4(),
        "name": `Client ${random}`,
        "lastName": `LastName ${random}`,
        "email": `client-lastname-${random}@fake.com`,
        "address": {
            "country": "Colombia",
            "state": "Bogotá",
            "city": "Bogotá",
            "addressValue": `Calle siempre viva ${random}`,
            "codePostal": 111611
        }
    });

    let response = await http.asyncRequest('POST', 'http://localhost:5000/api/client', order, params);

    check(response, {
        'is status 204': (r) => r.status === 204,
    });

    sleep(1);
}