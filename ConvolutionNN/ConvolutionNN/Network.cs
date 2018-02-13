using System;

public class Network
{
    //Variables for each layer length
    public int input_layer_length;
    public int[] hidden_layers_length;
    public int output_layer_length;

    //Initailizing the layer data for the network
    //Data for input layer;
    public double[] input_layer_data;
    public double[] input_error; //Error signals for input data.

    //Data for hidden layer
    public double[][] hidden_layer_data;
    public double[][] hidden_error; //Error signals for each hidden layer data.

    //Data for output layer
    public double[] exprectResult_layer_data;
    public double[] out_error; //Error signals for output layer data.

    //Array for layer data;
    public double[][] layerSizes;

    //Weights and biases.
    public double[][] weights, biases; //Initializing weights and biases.

    //Method to initialize the network size.
    public void initializeNetwork(int inputSize, int[] hiddenLayerSize, int outputLayerSize)
    {
        this.input_layer_length = inputSize.Length; //Initializing the length for the input layer.
        for (int i = 0; i < hiddenLayerSize.Length; i++) //Initializing the length for each input layer.
        {
            hidden_layers_length[i] = hiddenLayerSize[i];
        }
        this.output_layer_length = outputLayerSize; //Initializing the length for each input layer.
        
    }

    //Neural Network Methods.
    public double activateNeuron(double weight, double bias, double input)
    {
        double activation = (weight * input) + bias;
        return activation;
    }

    public double Sigmoid(double activatedNeuron) //Sigmoid function TODO: Replace with ReLU.
    {
        return 1 / (1 + Math.Exp(activatedNeuron));
    }

    public double derive_neuron(double outputNeuron) //Function used to calculate derivitive.
    {
        double derivative = outputNeuron * (1.0 - outputNeuron);
        return derivative;
    }

    public double calculateError(double expectedNeuron, double resultingNeuron) //Function used to take the resulting neuron and the expected neuron and calculate the error.
    {
        double error = (expectedNeuron - resultingNeuron) * derive_neuron(resultingNeuron);
        return error;
    }

    public double backPropError(double[] currentLayer, double[] previousLayer)
    {
        for (int currentNeuron = currentLayer.Length; currentNeuron > 0; currentNeuron--) //Reverse iterate through all current neurons
        {
            for (int prevNeuron = previousLayer.Length; prevNeuron > 0; prevNeuron--) //Reverse iterate through all previous neurons
            {
                
            }
        }

    }

    public double propagateInputs(double[][] currentlayer, double[][] nextLayer) //Forward porpigation function.
    {
        for (int layer = 0; layer < currentlayer.GetLength(0); layer++) //Iterating through all of the current layers neurons.
        {
            for (int neuron = 0; neuron < currentlayer.GetLength(1); neuron++)
            {
                double current_neuron_activation = Sigmoid(weights[layer][neuron], biases[layer][neuron], currentlayer[layer][neuron]); //Getting the activation for each neuron.
                nextLayer[layer][neuron] = activateNeuron[neuron]; //Assigning each neuron on the next layer with the appropriate values.
            }
        }
    }

    //Method for getting resulting data for each working layer.
    public double[] proccessData(double[] inputLayer)
    {
        
    }

    //used for GUESSING neuron values.
    public double[] constructGuess(double minimum_size, double maximum_size, int array_length) //I am calling it a guess and nobody can stop me.
    {
        //Create Random value.
        Random arrayRanGen = new Random();
        //CreateArrayTemplate.
        double[] finalArray = new double[array_length];
        for (int i = 0; i < array_length; i++)
        {
            finalArray[i] = arrayRanGen.NextDouble * (maximum_size - minimum_size) + minimum_size;
        }
        //Check if the size is appropriate before return array.
        if (array_length < 1) return null;
        else return finalArray;
    }

	public Network(double[] input_data, double[][] hidden_layers, double[] output_data)
	{
        
	}
}

















//Why did you scroll past the last bracket you nunce