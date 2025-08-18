// <copyright file="AlgorithmBase.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Algorithm;

public abstract class AlgorithmBase<T>
{
#pragma warning disable CS0693 // Type parameter has the same name as the type parameter from outer type
    public delegate int Comparer<in T>(T first, T second);
#pragma warning restore CS0693 // Type parameter has the same name as the type parameter from outer type

    public abstract void Sort(IList<T> collection, Comparer<T> comparer);
}
