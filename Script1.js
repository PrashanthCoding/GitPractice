function secondLargest(arr) {
    let largest = Math.max(...arr);
    arr.splice(arr.indexOf(largest), 1);
    return Math.max(...arr);
}

console.log(secondLargest([10, 20, 30, 5]));
