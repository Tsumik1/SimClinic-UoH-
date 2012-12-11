using System;
using System.Collections;
using System.Collections.Generic;

public static class ListExtension
{

	
public static void Shuffle<T>(this List<T> list)
{  
    Random rng = new Random();  
    int n = list.Count;  
    while (n > 1) {  
        n--;  
        int k = rng.Next(n + 1);  
        T value = list[k];  
        list[k] = list[n];  
        list[n] = value;  
    }  
}
}