// Dans script1.js
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
                        <div class="row mt-3 input-group" id="reponses">
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
function validateResponse() {
    var divName = `.div${countQuestion}_reponse\\[\\]`;
    var divsAvecLaMemeClasse = document.querySelectorAll(divName);
    divsAvecLaMemeClasse.forEach(function (section) {
        var inputs = section.querySelectorAll('input');
        inputs.forEach(function (input) {
            input.setAttribute('readonly', 'readonly');
            //    input.setAttribute('disabled', 'disabled');
        });
        var selects = section.querySelectorAll('select');
        selects.forEach(function (selct) {
            // selct.setAttribute('disabled', 'disabled');
        });
    });
}
document.write('<script src="generateQuestionPart2.js"></script>');
