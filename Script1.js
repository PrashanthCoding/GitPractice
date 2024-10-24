function findLargestIn2DArray(arr) {
    let largest = Number.NEGATIVE_INFINITY;
    for (let i = 0; i < arr.length; i++) {
        for (let j = 0; j < arr[i].length; j++) {
            if (arr[i][j] > largest) {
                largest = arr[i][j];
            }
        }
    }
    return largest;
}

const array2D = [[1, 2, 3], [4, 5, 6], [7, 8, 9]];
console.log(findLargestIn2DArray(array2D));  // Output: 9
