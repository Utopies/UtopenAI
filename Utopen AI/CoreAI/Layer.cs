namespace Utopen_AI.CoreAI;

class Layer
{
    public float[] Outputs;
    private float[,] _weights;
    private float[] _biases;

    public Layer(int inputSize, int neuronsCount)
    {
        _weights = new float[inputSize, neuronsCount];
        _biases = new float[neuronsCount];
    }
    
    public Layer(){
        RandomInitializeWeights();
        RandomInitializeBiases();
    }
    
    private void RandomInitializeWeights()
    {
        for (int i = 0; i < _weights.GetLength(0); i++)
        {
            for (int j = 0; j < _weights.GetLength(1); j++)
            {
                _weights[i, j] = (Random.Shared.Next(222, 223) % 2 == 0) ? 
                    (float) Random.Shared.NextDouble() : (float) -Random.Shared.NextDouble() ;
            }
        }
    }

    private void RandomInitializeBiases()
    {
        for (int i = 0; i < _biases.Length; i++)
        {
            _biases[i] = (Random.Shared.Next(222, 223) % 2 == 0) ? 
                (float) Random.Shared.NextDouble() :  (float) -Random.Shared.NextDouble() ;
        }
    }
    private float[] CalcOutputs(float[] inputs)
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
        //return (float) (Math.Pow(UMath.E, (x * 2)) - 1) / (float) (Math.Pow(UMath.E, (x * 2)) + 1);
        return (float)Math.Tanh(x);
    }
}