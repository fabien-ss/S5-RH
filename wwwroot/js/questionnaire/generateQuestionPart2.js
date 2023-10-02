function ajouterReponse(button) {
    var reponseDiv = button.parentElement.querySelector("#reponses");
    var nouvelleReponse = document.createElement("div");
    nouvelleReponse.className = "col-6";
    const name = `question${countQuestion}_reponse[]`;
    const validation = `question${countQuestion}_reponse_validation[]`;
    const divName = `div${countQuestion}_reponse[]`;
    nouvelleReponse.innerHTML = `
            <div class="input-group ${divName} d-flex mt-3" id="" style="grid-gap: 0px">
                <input type="text" class="form-control me-2 rounded" name="${name}" aria-label="Réponse" aria-describedby="search-addon" />
                <select name="${validation}" class="form-select">
                    <option class="form-select" value="0">Faux</option>
                    <option class="form-select" value="1">Vrai</option>
                </select>
            </div>
            `;
    reponseDiv.appendChild(nouvelleReponse);
}
function attributeValue(check){
    if(check.checked){
        check.value = 1;
    }
    else{
        check.value = 2;
    }
}
function verrouillerChamps() {
    var inputs = document.querySelectorAll("questionForm input");
    for (var i = 0; i < inputs.length; i++) {
        inputs[i].readOnly = true;
    }
    var boutonVerrouillage = document.getElementById("buttonVerrouiller");
    boutonVerrouillage.disabled = true;
}
function createValidationButton() {
    var existingButton = document.getElementById("validationButton");
    if (!existingButton) {
        var validationButton = document.createElement("button");
        validationButton.setAttribute("class","btn btn-primary mt-3");
        validationButton.setAttribute("type","submit");
        validationButton.textContent = "Valider";
        validationButton.id = "validationButton";
        var buttonsContainer = document.getElementById("buttonQuestion");
        buttonsContainer.appendChild(validationButton);
    }
    inputQuestionNumber.value = countQuestion;
}
function envoyer(button){
    button.setAttribute("type", "submit");
    button.setAttribute("class", "btn btn-primary mt-3");
    button.textContent="Envoyer";
    var ajoutButton=document.getElementById("ajoutQuestion");
    ajoutButton.remove("click", validerOption);
}
function validerOption(validationButton){
    envoyer(validationButton);
}