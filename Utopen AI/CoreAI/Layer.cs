namespace Utopen_AI.CoreAI;

struct Layer
{
    public float[] Outputs;
    private float[,] _weights;
    private float[] _biases;

    private void RandomInitializeWeights()
    {
        for (int i = 0; i < _weights.GetLength(0); i++)
        {
            for (int j = 0; j < _weights.GetLength(1); j++)
            {
                sbyte rnd = (sbyte) Random.Shared.Next(sbyte.MinValue, sbyte.MaxValue);
                _weights[i, j] = (rnd != 0)? (float) Math.Round((float) 1 / rnd, 4) : 0;
            }
        }
    }

    private float[] calcOutputs(float[] inputs)
    {
        Outputs = new float[_biases.Length];
        for (int j = 0; j < _biases.Length; j++)
        {
            float sum = _biases[j];
            for (int i = 0; i < inputs.Length; i++)
            {
                sum += inputs[i] * _weights[i, j]; 
            }
            Outputs[j] = Activate(sum);
        }
        return Outputs;
    }
    
    private float Activate(in float x)
    {
        return (float) (Math.Pow(UMath.E, (x * 2)) - 1) / (float) (Math.Pow(UMath.E, (x * 2)) + 1);
    }
}