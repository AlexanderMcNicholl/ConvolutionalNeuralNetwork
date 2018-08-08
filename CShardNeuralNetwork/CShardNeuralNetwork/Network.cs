using System;

namespace CShardNeuralNetwork {

    class Network
    {
        /*
         Information:

            Firstly, this network does use not directly list the hold all of the weights in an array, instead it
            Holds all of the information in the three dimensional 'synapses' array, the first dimension is the layer,
            the second dimension is the neuron and the third dimension is simply the previouse neuron (the previous layer
            is not required because it can simply be found from subtracting 1 from the current layer's index.

        */
        static double[][][] synapses;
        static double[][] layers;
        static double[][] derived_layer_neurons;
        static double[][] errors;

        static void constructNetwork(double[] inputs, int[] hiddenLayerLength, double[] expected) //Method to construct the network.
        {
            //Initializing layers.
            int hiddenLayerSize = 0;
            for (int i = 0; i < hiddenLayerLength.Length; i++)
            {
                hiddenLayerSize += hiddenLayerLength[i];
            }
            int layerSize = 1 + (hiddenLayerLength.Length) + 1;
            layers = new double[layerSize][];
            layers[0] = inputs;
            for (int i = 0; i < hiddenLayerLength.Length; i++)
            {
                double[] hidden_layer = initializeArray(hiddenLayerLength[i]);
                layers[1 + i] = hidden_layer;
            }
            errors = new double[layerSize][];
            layers[layerSize - 1] = expected;
            int synapse_layer_size = 0;
            for (int sLength = 1; sLength < layers.GetLength(0); sLength++) synapse_layer_size += 1;
            synapses = new double[layers.GetLength(0)][][];
            errors = new double[layers.GetLength(0)][];
            for (int layer = 1; layer < layers.GetLength(0); layer++)
            {
                synapses[layer] = new double[layers[layer].Length][];
                errors[layer] = new double[layers[layer].Length];
                for (int neuron = 0; neuron < layers[layer].Length; neuron++)
                {
                    synapses[layer][neuron] = new double[layers[layer - 1].Length];
                }
            }
            printNetwork(inputs, hiddenLayerLength, expected);
        }

        static void calculateErrors()
        {
            for (int layer = 1; layer < layers.GetLength(0); layer++)
            {
                for (int neuron = 0; neuron < layers[layer].Length; neuron++)
                {
                    for (int previousNeuron = 0; previousNeuron < layers[layer - 1].Length; previousNeuron++)
                    {
                        synapses[layer][neuron][previousNeuron] = generateRandomWeight();
                        errors[layer][neuron] = layers[layer][neuron] - layers[layer - 1][previousNeuron];
                        Console.WriteLine("Error of " + layers[layer][neuron] + " and " + layers[layer - 1][previousNeuron] + " is " + errors[layer][neuron]);
                    }
                }
            }
        }

        static void train_network(double learning_rate)
        {
            for (int layer = 1; layer < layers.GetLength(0); layer++)
            {
                for (int neuron = 0; neuron < layers[layer].Length; neuron++)
                {
                    double neuron_delta = -learning_rate * errors[layer][neuron];
                    for (int previous_neuron = 0; previous_neuron < layers[layer - 1].Length; previous_neuron++)
                    {
                        synapses[layer][neuron][previous_neuron] += neuron_delta * layers[layer - 1][previous_neuron]; //It is the code that defines the weight for each neuron.
                    }
                }
            }
        }

        static double Sigmoid(double x)
        {
            return 1d / (1 + Math.Exp(-x));
        }

        static void propagateErrors()
        {

        }

        static void Main()
        {
            double[] input_layers = { 1, 7, 4};
            int[] hidden_layer_length = { 8, 2, 1};
            double[] out_layer = { 0, 1 };
            constructNetwork(input_layers, hidden_layer_length, out_layer);
            //initializeWeights(1)
            calculateErrors();
            Console.ReadLine();
        }

        static double[] initializeArray(int arrayLength)
        {
            Random r = new Random();
            double[] returnArray = new double[arrayLength];
            for (int i = 0; i < arrayLength; i++)
            {
                returnArray[i] = r.NextDouble();
            }
            return returnArray;
        }

        static double generateRandomWeight()
        {
            return new Random().NextDouble();
        }

        static void printNetwork(double[] inputs, int[] hiddenLayerLength, double[] expected) //Method to print the networks layers and all of its neurons.
        {
            Console.WriteLine("                                 Neural Network developed by Alexander McNicholl\n\n\n\n");
            Console.WriteLine("Network information:\n");
            String lineBreak = "-----------------------------------------------------------";
            Console.WriteLine(" Network size: " + layers.GetLength(0));
            int layerSize = 1 + hiddenLayerLength.Length + 1;
            Console.WriteLine();
            Console.WriteLine("     Input layer:");
            Console.WriteLine(lineBreak);
            for (int i = 0; i < layers[0].Length; i++)
            {
                Console.WriteLine("     Input layer (Neuron " + (i + 1) + "): " + layers[0][i]);
            }
            Console.WriteLine();
            for (int hiddenLayer = 1; hiddenLayer < hiddenLayerLength.Length + 1; hiddenLayer++)
            {
                Console.WriteLine("     Hidden layer: " + hiddenLayer);
                Console.WriteLine(lineBreak);
                for (int i = 0; i < layers[hiddenLayer].Length; i++)
                {
                    Console.WriteLine("     Neuron " + (i + 1) + ": " + layers[hiddenLayer][i]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("     Expected output layers:");
            Console.WriteLine(lineBreak);
            for (int i = 0; i < layers[layerSize - 1].Length; i++)
            {
                Console.WriteLine("     Expect output layer (Neuron " + (i + 1) + "): " + layers[layerSize - 1][i]);
            }
            //Print synapse information here.
        }
    }
}
