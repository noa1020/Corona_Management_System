const memberUri = '/Member';
let members = [];

// Fetches members from the server
async function GetMembers() {
    fetch(memberUri, {
        method: 'GET',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json',
        },
    }).then(async response => {
        if (!response.ok) {
            const errorMessage = await response.text();
            const errorMessageFirstLine = errorMessage.split(' at ')[0];
            throw new Error(errorMessageFirstLine);
        }
        return response.json();
    })
        .then(data => { members = data; DisplayMembers(); })
        .catch(error => console.error('Error geting members.', error));
}

// Deletes a member by memberId
function DeleteMember(memberId) {
    fetch(`${memberUri}/${memberId}`, {
        method: 'DELETE',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json',
        },
    }).then(async response => {
        if (!response.ok) {
            const errorMessage = await response.text();
            const errorMessageFirstLine = errorMessage.split(' at ')[0];
            throw new Error(errorMessageFirstLine);
        }
    }).catch(error => alert(error));
    location.reload();
}

// Updates member information
async function UpdateMember(member) {
    try {
        const response = await fetch(memberUri, {
            method: 'PUT',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(member)
        });

        if (!response.ok) {
            const errorMessage = await response.text();
            const errorMessageFirstLine = errorMessage.split(' at ')[0];
            throw new Error(errorMessageFirstLine);
        }
    } catch (error) {
        alert(error);
    }
    location.reload();
}

// Add new member 
async function AddMember(member) {
    try {
        const response = await fetch(memberUri, {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(member)
        });

        if (!response.ok) {
            const errorMessage = await response.text();
            const errorMessageFirstLine = errorMessage.split(' at ')[0];
            throw new Error(errorMessageFirstLine);
        }
    } catch (error) {
        alert(error);
    }
    location.reload();
}