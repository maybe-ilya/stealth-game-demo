using System;
using UnityEditor;
using UnityEngine;

namespace MIG.Editor
{
    public sealed class HandlesColorScope : IDisposable
    {
        private readonly Color _originalColor;

        private Color Color
        {
            get => Handles.color;
            set => Handles.color = value;
        }

        public HandlesColorScope(Color newColor)
        {
            _originalColor = Color;
            Color = newColor;
        }

        public void Dispose()
        {
            Color = _originalColor;
        }
    }
}