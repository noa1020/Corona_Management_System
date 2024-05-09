const vaccinationUri = '/Vaccination';
let vaccinationsArr;

//fetch all vaccinations
async function GetVaccination() {
    try {
        const response = await fetch(vaccinationUri, {
            method: 'GET',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
            },
        });
        if (!response.ok) {
            const errorMessage = await response.text();
            throw new Error( errorMessage);
        }
        return response.json();
    } catch (error) {
        throw new Error('Unable to get Vaccinations.' + error.message);
    }
}

