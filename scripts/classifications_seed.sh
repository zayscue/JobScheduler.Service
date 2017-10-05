#!/bin/bash
# classifications seed script
mongoimport --db scheduling --collection classifications --drop --file ./classifications_seed.json