// function checkingEvenNumbers(num)
// {
//     return num%2==0//boolean
// }


// function filteringEvenNumbers(numbers,callbackFunc)
// {
//     let numberArray=[]
//     for(let value of numbers)
//     {
//         if(callbackFunc(value))
//             numberArray.push(value)
//     }
//     return numberArray
// }

// let arrayOfNumbers=[22,45,99,3,8,44]
// console.log(filteringEvenNumbers(arrayOfNumbers,checkingEvenNumbers))


// //reduce
// // let arrayOfNumbers=[1,2,3,4,5]
// // let sumOfArrayElements=arrayOfNumbers.reduce((sum,value)=>{
// // return sum+value
// // })
// // console.log(sumOfArrayElements)

// //foreach
// // let arrayOfNumbers=[22,45,99,3,8,44]
// // arrayOfNumbers.forEach(num=>{console.log(num)})

// //sort
// let arrayOfNumber=[22,45,99,3,8,44]
// arrayOfNumber.sort((numOne,numTwo)=>numOne-numTwo)
// console.log(arrayOfNumber)

const dateDisplay=()=>{
    document.getElementById('demo').innerHTML=Date()
}