const regForm = document.getElementById("regForm")
const firstName = document.getElementById("firstName")
const errorFirstName = document.getElementById("error-firstName")
const lastName = document.getElementById("lastName")
const errorLastName = document.getElementById("error-lastName")
const results = document.getElementById("results")


 function validateLength(event, name) {
  const error = document.getElementById(`error-${event.target.id}`)

     if(event.target.value === "")
          error.innerText = `Du måste ange ett ${name}`
      else{
         if(event.target.value.length < 2)
            error.innerText = `${name} måste bestå av minst 2 Tecken.`
         else
             error.innerText = ""
        }
    }

     firstName.addEventListener("keyup", function(event){
         const name = "Förnamn"
         validateLength(event, name)
     })
     lastName.addEventListener("keyup", function(event){
        const name = "Efternamn"
        validateLength(event, name)
    })