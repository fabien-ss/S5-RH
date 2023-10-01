var inputQuestionNumber = document.getElementById("nombreDeQuestion");
var canGenerate = true;
var countQuestion = 0;
function ajouterQuestion() {
    if(canGenerate == true){
        countQuestion += 1;
        const questionName = `question${countQuestion}_question`;
        var questionDiv = document.getElementById("questions");
        var nouvelleQuestion = document.createElement("div");
        var divName = `div${countQuestion}_question[]`;
        var buttonName = `ajouter${countQuestion}_question[]`;
        nouvelleQuestion.className = "form-group mt-3";
        nouvelleQuestion.innerHTML = `
                <div class = "col-12">
                    <label class="Question mt-3">Entrée la question</label>
                    <input type="text" class="form-control" name="${questionName}" id="${questionName}" />
                        <div class="row mt-3" id="reponses">
                        </div>
                    <button class="btn btn-default mt-3" id="${buttonName}" onclick="ajouterReponse(this)" type="button"><i class="fas fa-plus"></i></button>
                    <button class="btn btn-default mt-3" onclick="valider(this)" type="button"><i class="fas fa-check"></i></button>
                </div>
                `;
        questionDiv.appendChild(nouvelleQuestion);
        canGenerate = false;
    }
}

function valider(button){
    canGenerate = true;
    const questionName = `question${countQuestion}_question`;
    var question = document.getElementById(questionName);
    question.setAttribute("readonly", "readonly");
    var buttonName = `ajouter${countQuestion}_question[]`;
    var elementASupprimer = document.getElementById(buttonName);
    validateResponse();
    elementASupprimer.remove();
    button.remove();
    createValidationButton();
}
function validateResponse(){
    var divName = `.div${countQuestion}_reponse\\[\\]`;
    var divsAvecLaMemeClasse = document.querySelectorAll(divName);
    divsAvecLaMemeClasse.forEach(function(section){
        var inputs = section.querySelectorAll('input');
        inputs.forEach(function(input){
            input.setAttribute('readonly', 'readonly');
        //    input.setAttribute('disabled', 'disabled');
        });
        var selects = section.querySelectorAll('select');
        selects.forEach(function (selct){
           // selct.setAttribute('disabled', 'disabled');
        });
    });

}
function ajouterReponse(button) {
    var reponseDiv = button.parentElement.querySelector("#reponses");
    var nouvelleReponse = document.createElement("div");
    nouvelleReponse.className = "col-6";
    const name = `question${countQuestion}_reponse[]`;
    const validation = `question${countQuestion}_reponse_validation[]`;
    const divName = `div${countQuestion}_reponse[]`;
    nouvelleReponse.innerHTML = `
            <div class="form-inline ${divName} d-flex" id="">
                <input type="text" class="form-control me-2" name="${name}"/>
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