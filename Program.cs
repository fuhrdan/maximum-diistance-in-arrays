//*****************************************************************************
//** 624. Maximum Distance in Arrays           leetcode                      **
//** Find the largest distance between two arrays.                           **
//*****************************************************************************

int maxDistance(int** arrays, int arraysSize, int* arraysColSize) {
    int max = INT_MIN;  // Initialize to the smallest possible integer
    int min = INT_MAX;  // Initialize to the largest possible integer
    int maxI = -1;      // Index of the array that holds the maximum value
    int minI = -1;      // Index of the array that holds the minimum value
    int secondMax = INT_MIN;  // To hold the second-best max value
    int secondMin = INT_MAX;  // To hold the second-best min value

    // Loop through all arrays
    for (int i = 0; i < arraysSize; i++) {
        // Print out the current array's first and last elements
//        printf("arrays[%d][0] = %d AND arrays[%d][%d] = %d\n", i, arrays[i][0], i, arraysColSize[i], arrays[i][arraysColSize[i] - 1]);

        // Update the minimum value and track the array it comes from
        if (min > arrays[i][0]) {
            secondMin = min;  // Save the previous minimum before updating
            min = arrays[i][0];
            minI = i;
        } else if (secondMin > arrays[i][0]) {
            secondMin = arrays[i][0];  // Update the second minimum if necessary
        }

        // Update the maximum value and track the array it comes from
        if (max < arrays[i][arraysColSize[i] - 1]) {
            secondMax = max;  // Save the previous maximum before updating
            max = arrays[i][arraysColSize[i] - 1];
            maxI = i;
        } else if (secondMax < arrays[i][arraysColSize[i] - 1]) {
            secondMax = arrays[i][arraysColSize[i] - 1];  // Update the second maximum if necessary
        }
    }

//    printf("Max = %d from array %d and min = %d from array %d\n", max, maxI, min, minI);

    // Calculate the maximum possible distance
    int distance;
    if (maxI != minI) {
        // If the max and min come from different arrays
        distance = max - min;
    } else {
        // If the max and min come from the same array, consider second best options
        distance = (max - secondMin > secondMax - min) ? max - secondMin : secondMax - min;
    }

    return distance;
}