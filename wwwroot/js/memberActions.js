//Edit member logic
async function EditMember(inputs, image, editButton) {
    inputs.forEach(input => {
        input.removeAttribute('readonly');
        input.style.border = '1px solid blue';
    });
    image.textContent = "change image"
    image.onclick = () => UploadImage(image);
    editButton.textContent = 'Confirm Changes';
    editButton.style.backgroundColor = 'green';
    editButton.classList.add('confirm-button');
    editButton.removeEventListener('click', EditMember);

    editButton.addEventListener('click', async () => {
        const updatedMember = {
            "image": image.dataset.imageBytes,
        }
        if (inputs[3].value == '' || inputs[8].value == '') {
            alert('Please fill in all required fields');
            return;
        }

        inputs.forEach(input => {
            updatedMember[input.id] = input.value.trim();
            input.setAttribute('readonly', true);
            input.style.border = '';
        });
        updatedMember["dateOfBirth"] == '' ? updatedMember["dateOfBirth"] = null : updatedMember["dateOfBirth"] = new Date(updatedMember["dateOfBirth"]);
        await UpdateMember(updatedMember);
    });

}

// Display members logic
async function DisplayMembers() {
    const displayContainer = document.createElement('div');
    displayContainer.classList.add('display-container');

    members.forEach(async item => {
        const itemContainer = document.createElement('div');
        itemContainer.classList.add('item');

        const summary = document.createElement('div');
        summary.classList.add('summary');

        const basicInfoWithImage = document.createElement('div');
        basicInfoWithImage.classList.add('basic-info-with-image');

        const basicInfo = document.createElement('div');
        basicInfo.classList.add('basic-info');

        const Id = document.createElement('div');
        const IdInput = document.createElement('input');
        const IdLabel = document.createElement('label');
        IdLabel.textContent = "ID: ";
        IdInput.value = item.memberId;
        IdInput.setAttribute('readonly', true);
        IdInput.id = 'memberId';
        IdInput.pattern = '^\d{9}$';
        Id.append(IdLabel, IdInput);

        const firstName = document.createElement('div');
        const firstNameInput = document.createElement('input');
        const firstNameLabel = document.createElement('label');
        firstNameLabel.textContent = "first Name: ";
        firstNameInput.value = item.firstName;
        firstNameInput.setAttribute('readonly', true);
        firstNameInput.id = 'firstName';
        firstNameInput.pattern = "^[a-zA-Z\s]+$";
        firstName.append(firstNameLabel, firstNameInput);

        const lastName = document.createElement('div');
        const lastNameInput = document.createElement('input');
        const lastNameLabel = document.createElement('label');
        lastNameLabel.textContent = "last Name: ";
        lastNameInput.value = item.lastName;
        lastNameInput.setAttribute('readonly', true);
        lastNameInput.id = 'lastName';
        lastNameInput.pattern = "^[a-zA-Z\s]+$";
        lastName.append(lastNameLabel, lastNameInput);

        const dateOfBirth = document.createElement('div');
        const dateOfBirthInput = document.createElement('input');
        dateOfBirthInput.type = "date";
        const dateOfBirthLabel = document.createElement('label');
        dateOfBirthLabel.textContent = "Date of Birth: ";
        const dateOfBirthValue = new Date(item.dateOfBirth);
        dateOfBirthValue.setDate(dateOfBirthValue.getDate() + 1);
        dateOfBirthInput.value = dateOfBirthValue.toISOString().substring(0, 10);

        dateOfBirthInput.setAttribute('readonly', true);
        dateOfBirthInput.id = 'dateOfBirth';
        dateOfBirth.append(dateOfBirthLabel, dateOfBirthInput);

        basicInfo.append(Id, firstName, lastName, dateOfBirth);

        const image = document.createElement('button');
        image.classList.add("image-button");
        const imageBytes = item.image;
        image.dataset.imageBytes = imageBytes;
        image.style.backgroundImage = `url(${imageBytes})`;


        basicInfoWithImage.append(image, basicInfo);
        const arrows = document.createElement('div');
        arrows.classList.add('arrows');

        const personalarrow = document.createElement('button');
        personalarrow.classList.add('button');
        personalarrow.textContent = 'contact Information▼';
        personalarrow.onclick = () => showContactDetails(item, itemContainer, personalarrow, basicInfo, image);
        const covidarrow = document.createElement('button');
        covidarrow.classList.add('button');
        covidarrow.textContent = 'covid19 details▼';
        covidarrow.onclick = () => ShowCovid19Details(item, itemContainer, covidarrow);
        arrows.append(personalarrow, covidarrow);
        summary.append(basicInfoWithImage, arrows);


        itemContainer.append(summary);
        displayContainer.appendChild(itemContainer);
    });

    document.body.appendChild(displayContainer);
}

// Confirm deletion logic
function confirmDeletion(memberId) {
    if (window.confirm("Are you sure you want to delete this member?")) {
        DeleteMember(memberId);
    }
}

// Show contact details logic
async function showContactDetails(item, itemContainer, personalarrow, basicInfo, image) {
    if (itemContainer.querySelector('.contactdetails')) {
        itemContainer.querySelector('.contactdetails').remove();
        personalarrow.textContent = 'contact Information▼';

    }
    else {
        personalarrow.textContent = 'close contact Information▲';
        const contactdetails = document.createElement('div');
        contactdetails.classList.add('contactdetails');
        const phone = document.createElement('div');
        const phoneInput = document.createElement('input');
        const phoneLabel = document.createElement('label');
        phoneLabel.textContent = "Landline: ";
        phoneInput.value = item.landlinephone;
        phoneInput.setAttribute('readonly', true);
        phoneInput.id = 'landLinePhone';
        phoneInput.pattern = '^0\d{0,2}-?\d{7}$';
        phone.append(phoneLabel, phoneInput);

        const mobilePhone = document.createElement('div');
        const mobilePhoneInput = document.createElement('input');
        const mobilePhoneLabel = document.createElement('label');
        mobilePhoneLabel.textContent = "Mobile Phone: ";
        mobilePhoneInput.value = item.mobilePhone;
        mobilePhoneInput.setAttribute('readonly', true);
        mobilePhoneInput.id = 'mobilePhone';
        mobilePhoneInput.pattern = '^05\d(-|\s)?\d{7}$';
        mobilePhone.append(mobilePhoneLabel, mobilePhoneInput);
        contactdetails.append(phone, mobilePhone);

        const city = document.createElement('div');
        const cityInput = document.createElement('input');
        const cityLabel = document.createElement('label');
        cityLabel.textContent = "City: ";
        cityInput.value = item.city;
        cityInput.setAttribute('readonly', true);
        cityInput.id = 'city';
        cityInput.pattern = "^[a-zA-Z\s]+$";
        city.append(cityLabel, cityInput);

        const street = document.createElement('div');
        const streetInput = document.createElement('input');
        const streetLabel = document.createElement('label');
        streetLabel.textContent = "Street: ";
        streetInput.value = item.street;
        streetInput.setAttribute('readonly', true);
        streetInput.id = 'street';
        streetInput.pattern = "^[a-zA-Z\s]+$";
        street.append(streetLabel, streetInput);

        const houseNumber = document.createElement('div');
        const houseNumberInput = document.createElement('input');
        const houseNumberLabel = document.createElement('label');
        houseNumberLabel.textContent = "House Number: ";
        houseNumberInput.value = item.houseNumber;
        houseNumberInput.setAttribute('readonly', true);
        houseNumberInput.id = 'houseNumber';
        houseNumber.append(houseNumberLabel, houseNumberInput);

        contactdetails.append(city, street, houseNumber);

        const editButton = document.createElement('button');
        editButton.textContent = 'Edit member';
        editButton.classList.add('edit-button');
        const inputs = Array.from(basicInfo.querySelectorAll('input'));
        contactdetails.querySelectorAll('input').forEach(input => inputs.push(input));
        editButton.addEventListener('click', () => EditMember(inputs, image, editButton));

        const deleteButton = document.createElement('button');
        deleteButton.textContent = 'Delete member';
        deleteButton.classList.add('delete-button');
        deleteButton.addEventListener('click', () => confirmDeletion(item.memberId));

        contactdetails.append(editButton, deleteButton);

        itemContainer.appendChild(contactdetails);
    }
}

//Upload and display image logic
function UploadImage(button) {
    const input = document.createElement('input');
    input.type = 'file';
    input.accept = 'image/*';

    input.onchange = function (e) {
        const file = e.target.files[0];
        const reader = new FileReader();

        reader.onload = function (e) {
            const imageBytes = e.target.result;
            button.dataset.imageBytes = imageBytes;

            button.style.backgroundImage = `url(${imageBytes})`;
            button.textContent = 'Change Image';
        };

        reader.readAsDataURL(file);
    };

    input.click();
}

//save new memeber()
async function saveNewMember() {
    try {
        const memberId = document.getElementById("memberId").value.trim();
        const firstName = document.getElementById("firstName").value.trim();
        const lastName = document.getElementById("lastName").value.trim();
        const dateOfBirth = document.getElementById("dateOfBirth").value.trim();
        const phone = document.getElementById("phone").value.trim();
        const mobilePhone = document.getElementById("mobilePhone").value.trim();
        const city = document.getElementById("city").value.trim();
        const street = document.getElementById("street").value.trim();
        const houseNumber = document.getElementById("houseNumber").value.trim();
        let illnessDate = document.getElementById("illnessDate").value.trim();
        illnessDate == '' ? illnessDate = null : illnessDate = new Date(illnessDate);
        let recoveryDate = document.getElementById("recoveryDate").value.trim();
        recoveryDate == '' ? recoveryDate = null : recoveryDate = new Date(recoveryDate);
        const imageBytes = document.querySelector('.upload-image-button').dataset.imageBytes;
        let vaccinations = [];

        // Get all vaccination fields
        const vaccinationFields = Array.from(document.querySelectorAll(".vaccination-field"));
        vaccinationFields.forEach(field => {
            const vaccinationDate = field.querySelector("input[type='date']").value.trim();
            const vaccinationId = parseInt(field.querySelector("select").value);
            ;

            // Check if all required vaccination fields are filled
            const vaccination = {
                "memberId": memberId,
                "memberVaccinationId": 0,
                "vaccinationDate": vaccinationDate,
                "VaccinationId": vaccinationId,
            };
            vaccinations.push(vaccination);
        });
        // Prepare member data
        const memberData = {
            "memberId": memberId,
            "firstName": firstName,
            "lastName": lastName,
            "dateOfBirth": dateOfBirth,
            "landlinephone": phone,
            "mobilePhone": mobilePhone,
            "illnessDate": illnessDate,
            "recoveryDate": recoveryDate,
            "vaccinations": vaccinations,
            "image": imageBytes,
            "city": city,
            "street": street,
            "houseNumber": houseNumber,
        };

        await AddMember(memberData);
        console.log("Member data saved successfully!");
    } catch (error) {
        console.log("Error saving member data: " + error);
    }
}

function openForm() {
    document.getElementById("addmemberForm").style.display = "block";
}
function closeForm() {
    document.getElementById("addmemberForm").style.display = "none";
}